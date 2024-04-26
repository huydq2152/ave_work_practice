import React from "react";
import "./index.css";
import Element from "./Element";

export default class ImageGallery extends React.Component {
  render() {
    return (
      <div className="imagegallery">
        <div>
          <h1 style={{ marginTop: "25px" }}>Image Gallery</h1>
        </div>
        <div>
          <Element></Element>
        </div>
      </div>
    );
  }
}
