import React from "react";
import "./index.css";
import Documents from "./DocumentCategory/Documents";
import { documentsCategory } from "../../DummyData/dbDocCategory"
export default class DocumentGallery extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            list: documentsCategory
        }

    };
    render() {
        return (
            <div className="documentGallery">
                <div className="documentGalleryTitle"><h1>Document Gallery</h1></div>
                <div className="documentGalleryCategories">
                    {this.state.list.map((category, index) => {
                        return (
                            <Documents key={index} category={category} />
                        );
                    })}
                </div>
            </div>
        )
    }
}