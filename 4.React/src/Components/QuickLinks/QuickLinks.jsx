import React from "react";
import "./index.css";
import Image from "../../Base/Image.jsx"
export default class QuickLinks extends React.Component {
    render() {
        return (
            <div className="quick-links-content">
                <div className="quick-links-title"><h1>Quick Links</h1></div>               
                <div className="quick-content">
                    <div className="quick-item">
                        <img src={Image.icon} alt=""></img>
                        <div><p>Training</p></div>
                    </div>
                    <div className="quick-item">
                        <img src={Image.icon_1} alt=""></img>
                        <div><p>Organizations</p></div>
                    </div>
                    <div className="quick-item">
                        <img src={Image.icon_2} alt=""></img>
                        <div><p>Tasks</p></div>
                    </div>
                    <div className="quick-item">
                        <img src={Image.icon_3} alt=""></img>
                        <div><p>Global Sales</p></div>
                    </div>
                    <div className="quick-item" >
                        <img src={Image.icon_4} alt=""></img>
                        <div><p>Birthday</p></div>
                    </div>
                    <div className="quick-item">
                        <img src={Image.icon_5} alt=""></img>
                        <div><p>Health</p></div>
                    </div>
                    <div className="quick-item">
                        <img src={Image.icon_6} alt=""></img>
                        <div><p>Service Desk</p></div>
                    </div>
                    <div className="quick-item">
                        <img src={Image.icon_7} alt=""></img>
                        <div><p>Truck</p></div>
                    </div>
                    <div className="quick-item">
                        <img src={Image.icon_8} alt=""></img>
                        <div><p>Idea</p></div>
                    </div>
                </div>               
            </div>
        )
    }
}