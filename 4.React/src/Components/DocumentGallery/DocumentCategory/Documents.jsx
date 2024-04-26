import React from "react";
import "../index.css";
import { documents } from "../../../DummyData/dbDocuments";
import ViewMore from "../../Common/ViewMore";
export default class Documents extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            list: documents.filter((e) => {
                return this.props.category.category === e.category
            }),
            limit: 4,
        }
    };
    handleViewMoreClick() {
        this.setState({ limit: this.state.limit + 4 });
    };
    render() {
        return (
            <div className="document">
                <div className="documentTitle">
                    <h2>{this.props.category.title}</h2>
                </div>
                <div className="documentItems">
                    {this.state.list.slice(0, this.state.limit).map((doc, i) => {
                        return (
                            <div key={i} className="documentItem">
                                <img width="24" height="24" alt="" src={doc.image} ></img>
                                <div className="documentItemTitle">{doc.title}</div>
                            </div>
                        );
                    })}
                </div>
                <div>{this.state.list.length > this.state.limit &&
                    <ViewMore className="viewmore" onClick={this.handleViewMoreClick.bind(this)} />}
                </div>
            </div>
        )
    }
}