import * as React from "react";
import HomeWorkImages from "../../../../commons/image/HomeWorkImages";
import LoadingAnimation from "../../../../commons/loading/LoadingAnimation";
import ViewMore from "../../../../commons/viewmore/ViewMore";
import { getSP } from "../../../../pnpjsConfig";
import { DocumentGalleryService } from "../../../../services/DocumentGalleryService";
import styles from "../DocumentGallery.module.scss";
import { IDocumentGalleryDetailProps } from "./IDocumentGalleryDetailProps";
import { IDocumentGalleryDetailState } from "./IDocumentGalleryDetailState";

export default class DocumentGalleryDetailGalleryDetail extends React.Component<
  IDocumentGalleryDetailProps,
  IDocumentGalleryDetailState
> {
  private _documentGalleryService: DocumentGalleryService;

  constructor(
    props: IDocumentGalleryDetailProps,
    state: IDocumentGalleryDetailState
  ) {
    super(props);
    this.state = {
      documentList: [],
      pageToken: null,
      isLoading: true,
    };
    this._documentGalleryService = new DocumentGalleryService(
      props.listTitle,
      getSP(props.context)
    );
    this.onHandleViewMore = this.onHandleViewMore.bind(this);
  }

  getIconImage(document: any): string {
    let icon = document.DocIcon;
    switch (icon) {
      case "docx":
        return HomeWorkImages.word;
      case "pptx":
        return HomeWorkImages.powerpoint;
      case "pdf":
        return HomeWorkImages.vsdx;
    }
  }

  public getPageToken({ nextHref }: { nextHref?: string } = {}): string {
    //remove '?' in the first character in nextHref string
    return nextHref.slice(1);
  }

  public async componentDidMount() {
    let newDocList = await this._documentGalleryService.getDocCategoryItems(
      this.props.category.ServerRelativeUrl,
      this.props.pageNum,
      this.state.pageToken
    );
    this.setState({
      documentList: newDocList.Row,
      isLoading: false,
      pageToken: newDocList.NextHref
        ? this.getPageToken({ nextHref: newDocList.NextHref })
        : "",
    });
  }

  public onHandleViewMore = async () => {
    this.setState({
      documentList: this.state.documentList,
      isLoading: true,
      pageToken: this.state.pageToken,
    });
    let newDocList = await this._documentGalleryService.getDocCategoryItems(
      this.props.category.ServerRelativeUrl,
      this.props.pageNum,
      this.state.pageToken
    );

    this.setState({
      documentList: this.state.documentList.concat(newDocList.Row),
      isLoading: false,
      pageToken: newDocList.NextHref
        ? this.getPageToken({ nextHref: newDocList.NextHref })
        : "",
    });
  };

  public render(): React.ReactElement<IDocumentGalleryDetailProps> {
    return (
      <div className={styles.document}>
        <div className={styles.documentTitle}>{this.props.category.Name}</div>
        <div className={styles.documentItems}>
          {this.state.documentList.map((document: any, i: React.Key) => {
            return (
              <div key={i} className={styles.documentItem}>
                <img src={this.getIconImage(document)}></img>
                <div className={styles.documentItemTitle}>
                  {document.BaseName}
                </div>
              </div>
            );
          })}
        </div>
        {this.state.isLoading && <LoadingAnimation />}
        {this.state.pageToken && <ViewMore onClick={this.onHandleViewMore} />}
      </div>
    );
  }
}
