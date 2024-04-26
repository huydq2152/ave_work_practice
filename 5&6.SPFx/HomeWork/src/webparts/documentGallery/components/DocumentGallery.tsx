import * as React from "react";
import { IDocumentGalleryProps } from "./IDocumentGalleryProps";
import { IDocumentGalleryState } from "./IDocumentGalleryState";
import { DocumentGalleryService } from "../../../services/DocumentGalleryService";
import { getSP } from "../../../pnpjsConfig";
import DocumentGalleryDetail from "./DocumentGalleryDetail/DocumentGalleryDetail";
import styles from "./DocumentGallery.module.scss";

export default class DocumentGallery extends React.Component<
  IDocumentGalleryProps,
  IDocumentGalleryState
> {
  private _documentGalleryService: DocumentGalleryService;
  constructor(props: IDocumentGalleryProps, state: IDocumentGalleryState) {
    super(props);
    this.state = {
      categoryItems: [],
      isLoading: true,
    };
    this._documentGalleryService = new DocumentGalleryService(
      props.listTitle,
      getSP(props.context)
    );
  }

  public async componentDidMount() {
    try {
      let newCategoryItems = await this._documentGalleryService.getFolders();
      this.setState({
        categoryItems: newCategoryItems,
        isLoading: false,
      });
    } catch (e) {
      console.log(e);
    }
  }

  public render(): React.ReactElement<IDocumentGalleryProps> {
    return (
      <div className={styles.documentGallery}>
        <div className={styles.documentGalleryTitle}>Document Gallery</div>
        <div className={styles.documentGalleryItems}>
          {this.state.categoryItems.map((item, index) => {
            return (
              item.Name !== "Forms" && (
                <DocumentGalleryDetail
                  key={index}
                  pageNum={this.props.pageNumPerCategory}
                  category={item}
                  listTitle={this.props.listTitle}
                  context={this.props.context}
                />
              )
            );
          })}
        </div>
      </div>
    );
  }
}
