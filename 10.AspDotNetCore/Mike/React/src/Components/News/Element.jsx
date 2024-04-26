import React from "react";
import "./index.css";
import Image from "../../Base/Image";
import { createdAPIEndPoint, ENDPOINTS, FormatDate } from "../../api/index";
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
    createdAPIEndPoint(ENDPOINTS.NEW)
      .fetchPagedData(this.state.page + 1, 4)
      .then((res) => {
        let listNew = [...this.state.list, ...res.data];
        this.setState({
          list: listNew,
          listSeeMoreNews: new Array(listNew.length).fill(false),
          page: this.state.page + 1,
          hasNext: res.data.length < 4 ? false : true,
        });
        if (res.data.length === 4) {
          createdAPIEndPoint(ENDPOINTS.NEW)
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
      <div>
        {this.state.list.slice(0, this.state.limit).map((item, index) => (
          <div className="news" key={index}>
            <div className="news-image">
              <img width="200" height="150" src={item.image} alt=""></img>
            </div>
            <div className="news-content">
              <div className="news-title">{item.title} </div>
              <div className="news-detail">{item.content} </div>
              <div className="news-footer">
                <div className="news-icon">
                  <img src={Image.date} alt=""></img>
                </div>
                <div className="news-date">{FormatDate(item.creationTime)}</div>
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
