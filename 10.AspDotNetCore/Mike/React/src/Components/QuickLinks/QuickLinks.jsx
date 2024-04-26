import React from "react";
import "./index.css";
import Element from "../../Components/QuickLinks/Element";
export default class QuickLinks extends React.Component {
  render() {
    return (
      <div className="quick-links-content">
        <div className="quick-links-title">
          <h1 style={{ marginTop: "25px" }}>Quick Links</h1>
        </div>
        <Element />
      </div>
    );
  }
}
