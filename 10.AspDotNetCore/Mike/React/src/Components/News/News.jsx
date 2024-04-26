import React from "react";
import "./index.css";
import Element from "./Element";

export default class News extends React.Component {
  render() {
    return (
      <div className="news-list">
        <div>
          <h1 style={{ marginTop: "25px" }}>News</h1>
        </div>
        <div>
          <Element />
        </div>
      </div>
    );
  }
}
