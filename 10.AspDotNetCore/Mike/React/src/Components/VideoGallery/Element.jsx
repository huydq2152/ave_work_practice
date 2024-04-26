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
    createdAPIEndPoint(ENDPOINTS.VIDEOGALLERY)
      .fetchPagedData(this.state.page + 1, 4)
      .then((res) => {
        let listVideoGallery = [...this.state.list, ...res.data];
        this.setState({
          list: listVideoGallery,
          listSeeMoreVideoGallerys: new Array(listVideoGallery.length).fill(
            false
          ),
          page: this.state.page + 1,
          hasNext: res.data.length < 4 ? false : true,
        });
        if (res.data.length === 4) {
          createdAPIEndPoint(ENDPOINTS.VIDEOGALLERY)
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
          <div className="video" key={index}>
            <video
              width="200"
              height="150"
              className="video-content"
              poster={item.video}></video>
            <div className="video-button">
              <img
                width="50"
                height="50"
                src={Image.playVideoIcon}
                alt=""></img>
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
