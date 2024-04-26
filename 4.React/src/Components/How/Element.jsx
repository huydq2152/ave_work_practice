import React from "react";
import "./index.css";
import Image from "../../Base/Image.jsx";
import { how } from "../../DummyData/dbHow";
import ViewMore from "../Common/ViewMore";
export default class Element extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      how: how,
      activeIndex: null,
      limit: 8,
    };
  }
  handleViewMoreClick() {
    this.setState({ limit: this.state.limit + 4 });
  }

  toggleClass(index) {
    this.setState({
      activeIndex: this.state.activeIndex === index ? null : index,
    });
  }
  render() {
    return (
      <div>
        {this.state.how
          .filter((e) => {
            if (this.props.input === "") {
              return e;
            } else {
              return e.question.toLowerCase().includes(this.props.input);
            }
          })
          .slice(0, this.state.limit)
          .map((item, index) =>
            item.id === this.state.activeIndex ? (
              <div key={index}>
                <div
                  className="element-active"
                  onClick={this.toggleClass.bind(this, item.id)}>
                  <img
                    className="collapse"
                    src={Image.expand}
                    alt="View more"
                  />
                  <div
                    className="questionexpand"
                    onClick={this.toggleClass.bind(this, item.id)}>
                    {item.question}
                  </div>
                </div>
                <div className="answer-content">
                  <div className="author">{item.author}:</div>
                  <div className="answer">{item.answer}</div>
                </div>
              </div>
            ) : (
              <div
                key={index}
                className="element"
                onClick={this.toggleClass.bind(this, item.id)}>
                <img
                  className="collapse"
                  src={Image.collapse}
                  alt="View more"
                />
                <div
                  className="question"
                  onClick={this.toggleClass.bind(this, item.id)}>
                  {item.question}
                </div>
              </div>
            )
          )}
        <div>
          {this.state.how.length > this.state.limit && (
            <ViewMore onClick={this.handleViewMoreClick.bind(this)} />
          )}{" "}
        </div>
      </div>
    );
  }
}
