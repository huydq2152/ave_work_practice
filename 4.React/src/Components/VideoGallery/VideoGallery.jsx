import React from "react";
import "./index.css";
import Element from "./Element";

export default class VideoGallery extends React.Component {
    render() {
        return (
            <div className="videogallery">
                <div><h1>Video Gallery</h1></div>
                <div>
                    <Element ></Element>
                </div>               
            </div>
        )
    }
}