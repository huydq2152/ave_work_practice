import React from "react";
import "./index.css";
import Documents from "./DocumentCategory/Documents";
import { createdAPIEndPoint, ENDPOINTS } from "../../api/index";

export default class DocumentGallery extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      list: [],
    };
  }

  componentDidMount() {
    createdAPIEndPoint(ENDPOINTS.DOCUMENTCATEGORY)
      .fetchAll()
      .then((res) => {
        const listDocumentCategory = res.data;
        this.setState({ list: listDocumentCategory });
      });
  }

  render() {
    return (
      <div className="documentGallery">
        <div className="documentGalleryTitle">
          <h1 style={{ marginTop: "25px" }}>Document Gallery</h1>
        </div>
        <div className="documentGalleryCategories">
          {this.state.list.map((category, index) => {
            return <Documents key={index} category={category} />;
          })}
        </div>
      </div>
    );
  }
}
