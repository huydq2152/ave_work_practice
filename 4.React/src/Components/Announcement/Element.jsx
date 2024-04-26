import React from "react";
import "./index.css";
import Image from "../../Base/Image";
import { announcements } from "../../DummyData/dbAnnouncement";
import ViewMore from "../Common/ViewMore";
import ViewLess from "../Common/ViewLess";

export default class Element extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            list: announcements,
            listSeeMoreAnnouncements: new Array(announcements.length).fill(false),
            limit: 4,
        }
        this.handleViewMoreClick = this.handleViewMoreClick.bind(this)
        this.handleViewLessClick = this.handleViewLessClick.bind(this)
    };

    handleViewMoreClick() {
        this.setState({
            limit: this.state.limit + 4
        });
    };
    
    handleViewLessClick(e) {
        this.setState({
            limit: 4
        });
    }

    handleMoreDetailClick(index) {
        let shallowCopyArr = [...this.state.listSeeMoreAnnouncements];
        let item = { ...shallowCopyArr[index] };
        if (this.state.listSeeMoreAnnouncements[index] === false) {
            item = true;
        } else {
            item = false;
        }
        shallowCopyArr[index] = item;
        this.setState({
            listSeeMoreAnnouncements: shallowCopyArr
        });
    }

    render() {
        return (
            <div>
                {
                    this.state.list.slice(0, this.state.limit).map((item, index) => {
                        let classNameOfAnnouncementDetail;
                        let moreDetailButtonDisplay;
                        if (this.state.listSeeMoreAnnouncements[item.id] === true) {
                            classNameOfAnnouncementDetail = 'announcement-detail-full';
                            moreDetailButtonDisplay = 'See less'
                        } else {
                            classNameOfAnnouncementDetail = 'announcement-detail-compact';
                            moreDetailButtonDisplay = 'See more'
                        }

                        return (
                            <div className="announcement" key={index}>
                                <div className="announcement-image">
                                    <img width="200" height="150" src={item.image} alt=""></img>
                                </div>
                                <div className="announcement-content">
                                    <div className="announcement-title">{item.title} </div>
                                    <div className={classNameOfAnnouncementDetail}>{item.content} </div>
                                    <div
                                        className="moreDetail-btn"
                                        onClick={this.handleMoreDetailClick.bind(this, item.id)}
                                    >{moreDetailButtonDisplay}
                                    </div>
                                    <div className="announcement-footer">
                                        <div className="announcement-icon">
                                            <img src={Image.date} alt=""></img>
                                        </div>
                                        <div className="announcement-date">{item.date}</div>
                                        <div className="announcement-category">{item.category}</div>
                                    </div>
                                </div>
                            </div>

                        )
                    })
                }
                <div>{this.state.list.length > this.state.limit &&
                    <ViewMore className="viewmore" onClick={this.handleViewMoreClick} />}
                </div>
                <div>{this.state.list.length <= this.state.limit &&
                    <ViewLess className="viewLess" onClick={this.handleViewLessClick} />}
                </div>
            </div>
        )
    }
}