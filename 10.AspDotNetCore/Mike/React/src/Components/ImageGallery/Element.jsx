import React from "react";
import "./index.css";
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
    createdAPIEndPoint(ENDPOINTS.IMAGEGALLERY)
      .fetchPagedData(this.state.page + 1, 4)
      .then((res) => {
        let listImageGallery = [...this.state.list, ...res.data];
        this.setState({
          list: listImageGallery,
          listSeeMoreImageGallerys: new Array(listImageGallery.length).fill(
            false
          ),
          page: this.state.page + 1,
          hasNext: res.data.length < 4 ? false : true,
        });
        if (res.data.length === 4) {
          createdAPIEndPoint(ENDPOINTS.IMAGEGALLERY)
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
          <div className="image" key={index}>
            <img width="200" height="150" src={item.image} alt=""></img>
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
