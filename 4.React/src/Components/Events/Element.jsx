import React from "react";
import "./index.css";
import Image from "../../Base/Image.jsx"
import {events} from "../../DummyData/dbEvents"

import ViewMore from "../Common/ViewMore";
export default class Element extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            list: events,
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
            <div className="eventsItems">
                {
                    this.state.list.slice(0,this.state.limit).map((item,index) => ( 
                            <div key={index} className="eventsItem">
                                <div className="eventsDate">
                                  <div className="eventsDay">{item.day}</div>
                                  <div className="eventsMonth">{item.month}</div>
                                </div>
                                <div className="eventsContent">
                                  <div className="eventsItemTitle"> {item.title}</div>
                                  <div className="eventsItemTime">
                                    <img alt="" className="eventsIcon" src={Image.clock} />
                                    <div className="eventsItemStartEnd">{item.start} - {item.end}</div>
                                  </div>
                                </div>
                            </div>
                ))
                }
                <div>{this.state.list.length > this.state.limit &&
                    <ViewMore  className="viewmore"  onClick={this.handleViewMoreClick}/> }
                </div>
            </div>
        )
    }
}