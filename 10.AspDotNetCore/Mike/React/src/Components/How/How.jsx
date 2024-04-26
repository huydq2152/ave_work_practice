import React from "react";

import Image from "../../Base/Image.jsx";
import "./index.css";
import Element from "./Element";

export default class How extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      searchText: "",
      query: "",
    };

    this.searchHandler = this.searchHandler.bind(this);
    this.handleKeyDown = this.handleKeyDown.bind(this);
    this.handleChange = this.handleChange.bind(this);

    this.child = React.createRef();
  }

  searchHandler() {
    if (this.state.query) {
      var lowerCase = this.state.query.toLowerCase();
      this.setState({ searchText: lowerCase }, () => {
        this.child.current.handleSearchClick();
      });
    } else {
      this.setState({ searchText: "" }, () => {
        this.child.current.handleSearchClick();
      });
    }
  }

  handleChange(e) {
    this.setState({ query: e.target.value });
  }

  handleKeyDown(e) {
    if (e.key === "Enter") {
      this.searchHandler();
    }
  }

  render() {
    return (
      <div className="how">
        <h1 style={{ marginTop: "25px" }}>How Do I</h1>
        <div className="wrap-textfield">
          <img
            className="search-icon"
            src={Image.search}
            alt=""
            onClick={this.searchHandler}
          />
          <input
            className="search-input"
            type="text"
            placeholder="Find Questions"
            onChange={this.handleChange}
            onKeyDown={this.handleKeyDown}
          />
        </div>
        <Element ref={this.child} input={this.state.searchText} />
      </div>
    );
  }
}
