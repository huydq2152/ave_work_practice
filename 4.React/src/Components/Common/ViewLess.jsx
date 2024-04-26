import React from "react";
import Image from "../../Base/Image";
import "./index.css";
class ViewLess extends React.Component {
    render() {
        return (
          <div className="view-less" onClick={this.props.onClick}>
            <div className="view-less-content"> View less </div>
            <div className="view-less-icon">
              <img src={Image.arrowicon} alt = ""/>
            </div>
          </div>
        );
      }
  }
  
  export default ViewLess;