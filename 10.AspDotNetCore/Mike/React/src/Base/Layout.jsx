import React from "react";
import "./layout.css";
import Navigation from "../Components/Navigation/Navigation";
import Announcement from "../Components/Announcement/Announcement";
import QuickLinks from "../Components/QuickLinks/QuickLinks";
import News from "../Components/News/News";
import Events from "../Components/Events/Events";
import How from "../Components/How/How";
import ImageGallery from "../Components/ImageGallery/ImageGallery";
import VideoGallery from "../Components/VideoGallery/VideoGallery";
import DocumentGallery from "../Components/DocumentGallery/DocumentGallery";

export default class Layout extends React.Component {
    render() {
        return (
            <div className="portal-homepage">
                <div className="wrap">
                    <div className="header">
                        <Navigation />
                    </div>
                    <div className="content">
                        <div className="content-left">
                            <div id="announcement">
                                <Announcement />
                            </div>
                            <div id="news">
                                <News />
                            </div>
                            <div id="image-gallery">
                                <ImageGallery />
                            </div>
                            <div id="video-gallery">
                                <VideoGallery />
                            </div>
                            <div id="document-gallery">
                                <DocumentGallery />
                            </div>
                        </div>
                        <div className="content-right">
                            <div id="quick-links">
                                <QuickLinks />
                            </div>
                            <div id="events">
                                <Events />
                            </div>
                            <div id="how-do-i">
                                <How />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}