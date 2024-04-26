import * as React from "react";
import { IImageGalleryProps } from "./IImageGalleryProps";
import { IImageGalleryState } from "./IImageGalleryState";
import { ImageGalleryService } from "../../../services/ImageGalleryService";
import { getSP } from "../../../pnpjsConfig";
import { IImageGallery } from "../../../interfaces/IImageGallery";
import { PagedItemCollection } from "@pnp/sp/items";
import LoadingAnimation from "../../../commons/loading/LoadingAnimation";
import ViewMore from "../../../commons/viewmore/ViewMore";
import styles from "./ImageGallery.module.scss";

export default class ImageGallery extends React.Component<
  IImageGalleryProps,
  IImageGalleryState
> {
  private _imgGalleryService: ImageGalleryService;
  constructor(props: IImageGalleryProps, state: IImageGalleryState) {
    super(props);
    this.state = {
      imgGalleryList: [],
      hasNext: true,
      items: null,
      isLoading: true,
    };
    this._imgGalleryService = new ImageGalleryService(
      props.listTitle,
      getSP(props.context)
    );
  }

  public getNewImgGalleryItems(newItems: PagedItemCollection<IImageGallery[]>) {
    let newImgGalleryItems = this.state.imgGalleryList;
    newItems.results.forEach((element) => {
      let item = {
        title: element.Title,
        image: JSON.parse(element.Image).serverRelativeUrl,
      };
      newImgGalleryItems.push(item);
    });
    return newImgGalleryItems;
  }

  public async componentDidMount() {
    try {
      let newItems = await this._imgGalleryService.getPagedListItems(
        this.props.pageNum
      );
      let newImgGalleryItems = this.getNewImgGalleryItems(newItems);

      this.setState({
        imgGalleryList: newImgGalleryItems,
        hasNext: newItems.hasNext,
        items: newItems,
        isLoading: false,
      });
    } catch (e) {
      console.log(e);
    }
  }

  public onHandleViewMore = async () => {
    this.setState({
      isLoading: true,
    });
    if (this.state.hasNext) {
      let newItems = await this.state.items.getNext();
      let newImgGalleryItems = this.getNewImgGalleryItems(newItems);
      this.setState({
        imgGalleryList: newImgGalleryItems,
        hasNext: newItems.hasNext,
        items: newItems,
        isLoading: false,
      });
    }
  };

  public render(): React.ReactElement<IImageGalleryProps> {
    return (
      <div className={styles.imageGallery}>
        <div className={styles.imageGalleryTitle}>Image Gallery</div>
        <div className={styles.imageGalleryItems}>
          {this.state.imgGalleryList.map((item, index) => {
            return (
              <div key={index} className={styles.imageGalleryItem}>
                <img src={item.image} alt="" />
              </div>
            );
          })}
        </div>
        {this.state.isLoading && <LoadingAnimation />}
        {this.state.hasNext && <ViewMore onClick={this.onHandleViewMore} />}
      </div>
    );
  }
}
