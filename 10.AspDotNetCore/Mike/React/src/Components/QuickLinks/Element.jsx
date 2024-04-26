import React from "react";
import "./index.css";
import { createdAPIEndPoint, ENDPOINTS } from "../../api";

export default class Element extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      listQuickLink: [],
    };
  }

  componentDidMount() {
    createdAPIEndPoint(ENDPOINTS.QUICKLINK)
      .fetchAll()
      .then((res) => {
        const listQuickLink = res.data;
        this.setState({ listQuickLink: listQuickLink });
      });
  }

  render() {
    return (
      <div className="quick-content">
        {this.state.listQuickLink.map((item, index) => {
          return (
            <div key={index} className="quick-item">
              <img src={item.image} alt=""></img>
              <div>
                <p>{item.name}</p>
              </div>
            </div>
          );
        })}
      </div>
    );
  }
}
