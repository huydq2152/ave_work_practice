import React from "react";
import "./index.css";
import Element from "./Element";

export default class Events extends React.Component {
  render() {
    return (
      <div className="eventsChild">
        <div>
          <h1 style={{ marginTop: "25px" }}>Events</h1>
        </div>
        <div>
          <Element />
        </div>
      </div>
    );
  }
}
