import React from "react";
import "./index.css";
import Image from "../../Base/Image.jsx"
import { videoGallery } from "../../DummyData/dbVideoGallery"
import ViewMore from "../Common/ViewMore";


export default class Element extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            list: videoGallery,
            activeIndex: null,
            limit: 4,
        }
        this.handleViewMoreClick = this.handleViewMoreClick.bind(this)
    };
    handleViewMoreClick() {
        this.setState({ limit: this.state.limit + 4 });
    };
    render() {
        return (
            <div>{
                this.state.list.slice(0, this.state.limit).map((item, index) => (
                    <div className="video" key={index}>
                        <video width="200" height="150" className="video-content" poster={item.link} >
                        </video>
                        <div className="video-button">
                            <img width="50" height="50" src={Image.playVideoIcon} alt=""></img>
                        </div>
                    </div>
                ))
            }
                <div>
                    {
                        this.state.list.length > this.state.limit &&
                        <ViewMore className="viewmore" onClick={this.handleViewMoreClick}></ViewMore>
                    }
                </div>
            </div>
        )
    }
}
