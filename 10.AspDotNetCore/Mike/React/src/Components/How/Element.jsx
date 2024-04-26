import React from "react";
import "./index.css";
import Image from "../../Base/Image";
import { createdAPIEndPoint, ENDPOINTS } from "../../api/index";
import ViewMore from "../Common/ViewMore";

export default class Element extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      list: [],
      page: 0,
      hasNext: false,
    };
    this.handleViewMoreClick = this.handleViewMoreClick.bind(this);
  }

  toggleClass(index) {
    this.setState({
      activeIndex: this.state.activeIndex === index ? null : index,
    });
  }

  getFirstPage() {
    // console.log("input =", this.props.input);
    createdAPIEndPoint(ENDPOINTS.HOW)
      .fetchPagedAndFilteredData(1, 4, this.props.input)
      .then((res) => {
        let listHow = res.data;
        // console.log("listHow = ", listHow);
        this.setState({
          list: listHow,
          page: 1,
          hasNext: res.data.length < 4 ? false : true,
        });
      });
  }

  getMoreItems() {
    createdAPIEndPoint(ENDPOINTS.HOW)
      .fetchPagedAndFilteredData(this.state.page + 1, 4, this.props.input)
      .then((res) => {
        let listHow = [...this.state.list, ...res.data];
        this.setState({
          list: listHow,
          page: this.state.page + 1,
          hasNext: res.data.length < 4 ? false : true,
        });
        if (res.data.length === 4) {
          createdAPIEndPoint(ENDPOINTS.HOW)
            .fetchPagedAndFilteredData(this.state.page + 1, 4, this.props.input)
            .then((res) => {
              if (res.data.length === 0) {
                this.setState({
                  hasNext: false,
                });
              }
            });
        }
      });
  }

  componentDidMount() {
    this.getMoreItems();
  }

  handleViewMoreClick() {
    this.getMoreItems();
  }

  handleSearchClick() {
    this.getFirstPage();
  }

  render() {
    return (
      <div>
        {this.state.list.slice(0, this.state.limit).map((item, index) =>
          item.id === this.state.activeIndex ? (
            <div key={index}>
              <div
                className="element-active"
                onClick={this.toggleClass.bind(this, item.id)}>
                <img
                  className="collapse-icon"
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
                className="collapse-icon"
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
          {this.state.hasNext && (
            <ViewMore className="viewmore" onClick={this.handleViewMoreClick} />
          )}
        </div>
      </div>
    );
  }
}
