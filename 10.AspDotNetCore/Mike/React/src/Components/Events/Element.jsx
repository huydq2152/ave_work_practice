import React from "react";
import "./index.css";
import Image from "../../Base/Image";
import { createdAPIEndPoint, ENDPOINTS } from "../../api/index";
import ViewMore from "../Common/ViewMore";

export default class Element extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      list: [],
      page: 0,
      hasNext: false,
    };
    this.handleViewMoreClick = this.handleViewMoreClick.bind(this);
  }

  getMoreItems() {
    createdAPIEndPoint(ENDPOINTS.EVENT)
      .fetchPagedData(this.state.page + 1, 4)
      .then((res) => {
        let listEvent = [...this.state.list, ...res.data];
        this.setState({
          list: listEvent,
          listSeeMoreEvents: new Array(listEvent.length).fill(false),
          page: this.state.page + 1,
          hasNext: res.data.length < 4 ? false : true,
        });
        if (res.data.length === 4) {
          createdAPIEndPoint(ENDPOINTS.EVENT)
            .fetchPagedData(this.state.page + 1, 4)
            .then((res) => {
              if (res.data.length === 0) {
                this.setState({
                  hasNext: false,
                });
              }
            });
        }
      });
  }

  componentDidMount() {
    this.getMoreItems();
  }

  handleViewMoreClick() {
    this.getMoreItems();
  }

  render() {
    return (
      <div className="eventsItems">
        {this.state.list.slice(0, this.state.limit).map((item, index) => (
          <div key={index} className="eventsItem">
            <div className="eventsDate">
              <div className="eventsDay">{item.day}</div>
              <div className="eventsMonth">{item.month}</div>
            </div>
            <div className="eventsContent">
              <div className="eventsItemTitle"> {item.name}</div>
              <div className="eventsItemTime">
                <img alt="" className="eventsIcon" src={Image.clock} />
                <div className="eventsItemStartEnd">
                  {item.start} - {item.end}
                </div>
              </div>
            </div>
          </div>
        ))}
        <div>
          {this.state.hasNext && (
            <ViewMore className="viewmore" onClick={this.handleViewMoreClick} />
          )}
        </div>
      </div>
    );
  }
}
