import React from "react";
import Element from "./Element";

export default class Announcement extends React.Component {
  render() {
    return (
      <div className="announcements">
        <div>
          <h1 style={{ marginTop: "25px" }}>Announcements</h1>
        </div>
        <div>
          <Element />
        </div>
      </div>
    );
  }
}
