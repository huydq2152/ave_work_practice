import React from "react";
import "./index.css";
import Image from "../../Base/Image.jsx"
import {news} from "../../DummyData/dbNews"
import ViewMore from "../Common/ViewMore";

export default class Element extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            list: news,
            activeIndex:null,
            limit:4,
        }
        this.handleViewMoreClick = this.handleViewMoreClick.bind(this)
    };
    handleViewMoreClick(){
        this.setState({limit:this.state.limit+4});
    };
    render(){
        return(
            <div>
                {
                    this.state.list.slice(0,this.state.limit).map((item, index) => (   
                             
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
                                    <div className="news-date">{item.date}</div>
                                </div>
                            </div>     
                        </div>
                    
                ))
                }
                <div> {this.state.list.length > this.state.limit &&
                    <ViewMore  className="viewmore"  onClick={this.handleViewMoreClick}/>
                }
                </div>
            </div>
        )
    }
}