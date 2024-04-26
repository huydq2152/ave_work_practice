import React from "react";
import "./index.css";
import Image from "../../Base/Image.jsx";

import { Link } from "react-router-dom";
import { createdAPIEndPoint, ENDPOINTS } from "../../api";

export default class Navigation extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      nav: [],
    };
  }

  componentDidMount() {
    createdAPIEndPoint(ENDPOINTS.NAVIGATION)
      .fetchAll()
      .then((res) => {
        const listNav = res.data;
        this.setState({ nav: listNav });
      });
  }

  render() {
    return (
      <div className="nav">
        <div className="nav-logo">
          <img src={Image.logo} alt="logo" />
        </div>
        <div className="nav-items-left">
          {this.state.nav.map((item, index) => {
            return (
              <div key={index} class="nav-item">
                {item.name}
              </div>
            );
          })}
        </div>
        <div className="nav-items-right">
          <div class="nav-item">
            <Link to={`/admin`} className="nav-link">
              Admin Page
            </Link>
          </div>
        </div>
      </div>
    );
  }
}
