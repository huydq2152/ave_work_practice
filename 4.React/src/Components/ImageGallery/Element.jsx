import React from "react";
import "./index.css";
import {imageGallery} from "../../DummyData/dbImageGallery"
import ViewMore from "../Common/ViewMore";
export default class Element extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            list: imageGallery,
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
            <div>{
                this.state.list.slice(0,this.state.limit).map((item,index) => (                   
                        <div className="image" key={index}>
                            <img width="200" height="150" src={item.link} alt=""></img>
                        </div>
                ))
                }
                <div>{this.state.list.length > this.state.limit &&
                    <ViewMore  className="viewmore"  onClick={this.handleViewMoreClick}/>   
                    }
                </div>
            </div>
        )
    }
}