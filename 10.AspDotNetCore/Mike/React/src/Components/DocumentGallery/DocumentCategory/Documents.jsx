import React from "react";
import "../index.css";
import { createdAPIEndPoint, ENDPOINTS } from "../../../api/index";
import ViewMore from "../../Common/ViewMore";

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

  getMoreItems() {
    createdAPIEndPoint(ENDPOINTS.DOCUMENT)
      .fetchPagedDocumentByDocumentCategory(
        this.state.page + 1,
        4,
        this.props.category.id
      )
      .then((res) => {
        let listDocument = [...this.state.list, ...res.data];
        this.setState({
          list: listDocument,
          listSeeMoreDocuments: new Array(listDocument.length).fill(false),
          page: this.state.page + 1,
          hasNext: res.data.length < 4 ? false : true,
        });
        if (res.data.length === 4) {
          createdAPIEndPoint(ENDPOINTS.DOCUMENT)
            .fetchPagedDocumentByDocumentCategory(
              this.state.page + 1,
              4,
              this.props.category.id
            )
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

  render() {
    return (
      <div className="document">
        <div className="documentTitle">
          <h2>{this.props.category.name}</h2>
        </div>
        <div className="documentItems">
          {this.state.list.slice(0, this.state.limit).map((doc, i) => {
            return (
              <div key={i} className="documentItem">
                <img width="24" height="24" alt="" src={doc.image}></img>
                <a href={doc.fileUrl} className="documentItemTitle">
                  {doc.name}
                </a>
              </div>
            );
          })}
        </div>
        <div>
          {this.state.hasNext && (
            <ViewMore className="viewmore" onClick={this.handleViewMoreClick} />
          )}
        </div>
      </div>
    );
  }
}
