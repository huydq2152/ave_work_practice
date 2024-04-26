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
      listSeeMoreAnnouncements: [],
      page: 0,
      hasNext: false,
    };
    this.handleViewMoreClick = this.handleViewMoreClick.bind(this);
  }

  getMoreItems() {
    createdAPIEndPoint(ENDPOINTS.ANNOUNCEMENT)
      .fetchPagedData(this.state.page + 1, 4)
      .then((res) => {
        let listAnnouncement = [...this.state.list, ...res.data];
        this.setState({
          list: listAnnouncement,
          listSeeMoreAnnouncements: [
            ...this.state.listSeeMoreAnnouncements,
            new Array(4).fill(false),
          ],
          page: this.state.page + 1,
          hasNext: res.data.length < 4 ? false : true,
        });
        if (res.data.length === 4) {
          createdAPIEndPoint(ENDPOINTS.ANNOUNCEMENT)
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

  handleMoreDetailClick(announcementId) {
    let shallowCopyArr = [...this.state.listSeeMoreAnnouncements];
    let item = { ...shallowCopyArr[this.state.list.length] };
    if (
      this.state.listSeeMoreAnnouncements[announcementId] === false ||
      this.state.listSeeMoreAnnouncements[announcementId] === undefined
    ) {
      item = true;
    } else {
      item = false;
    }
    shallowCopyArr[announcementId] = item;
    this.setState({
      listSeeMoreAnnouncements: shallowCopyArr,
    });
  }

  render() {
    return (
      <div>
        {this.state.list.slice(0, this.state.limit).map((item, index) => {
          let classNameOfAnnouncementDetail;
          let moreDetailButtonDisplay;
          if (this.state.listSeeMoreAnnouncements[item.id] === true) {
            classNameOfAnnouncementDetail = "announcement-detail-full";
            moreDetailButtonDisplay = "See less";
          } else {
            classNameOfAnnouncementDetail = "announcement-detail-compact";
            moreDetailButtonDisplay = "See more";
          }

          return (
            <div className="announcement" key={index}>
              <div className="announcement-image">
                <img width="200" height="150" src={item.image} alt=""></img>
              </div>
              <div className="announcement-content">
                <div className="announcement-title">{item.title} </div>
                <div className={classNameOfAnnouncementDetail}>
                  {item.content}{" "}
                </div>
                <div
                  className="moreDetail-btn"
                  onClick={this.handleMoreDetailClick.bind(this, item.id)}>
                  {moreDetailButtonDisplay}
                </div>
                <div className="announcement-footer">
                  <div className="announcement-icon">
                    <img src={Image.date} alt=""></img>
                  </div>
                  <div className="announcement-date">
                    {FormatDate(item.creationTime)}
                  </div>
                  <div className="announcement-category">{item.category}</div>
                </div>
              </div>
            </div>
          );
        })}
        <div>
          {this.state.hasNext && (
            <ViewMore className="viewmore" onClick={this.handleViewMoreClick} />
          )}
        </div>
      </div>
    );
  }
}
