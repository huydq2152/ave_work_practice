import * as React from "react";
import { IVideoGalleryProps } from "./IVideoGalleryProps";
import { IVideoGalleryState } from "./IVideoGalleryState";
import { VideoGalleryService } from "../../../services/VideoGalleryService";
import { getSP } from "../../../pnpjsConfig";
import { PagedItemCollection } from "@pnp/sp/items";
import { IVideoGallery } from "../../../interfaces/IVideoGallery";
import ViewMore from "../../../commons/viewmore/ViewMore";
import LoadingAnimation from "../../../commons/loading/LoadingAnimation";
import styles from "./VideoGallery.module.scss";

export default class VideoGallery extends React.Component<
  IVideoGalleryProps,
  IVideoGalleryState
> {
  private _videoGalleryService: VideoGalleryService;
  constructor(props: IVideoGalleryProps, state: IVideoGalleryState) {
    super(props);
    this.state = {
      videoGalleryList: [],
      hasNext: true,
      items: null,
      isLoading: true,
    };
    this._videoGalleryService = new VideoGalleryService(
      props.listTitle,
      getSP(props.context)
    );
  }

  public getNewvideoGalleryItems(
    newItems: PagedItemCollection<IVideoGallery[]>
  ) {
    let newvideoGalleryItems = this.state.videoGalleryList;
    newItems.results.forEach((element) => {
      let item = {
        title: element.Title,
        image: JSON.parse(element.Image).serverRelativeUrl,
      };
      newvideoGalleryItems.push(item);
    });
    return newvideoGalleryItems;
  }

  public async componentDidMount() {
    try {
      let newItems = await this._videoGalleryService.getPagedListItems(
        this.props.pageNum
      );
      let newvideoGalleryItems = this.getNewvideoGalleryItems(newItems);

      this.setState({
        videoGalleryList: newvideoGalleryItems,
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
      let newvideoGalleryItems = this.getNewvideoGalleryItems(newItems);
      this.setState({
        videoGalleryList: newvideoGalleryItems,
        hasNext: newItems.hasNext,
        items: newItems,
        isLoading: false,
      });
    }
  };

  public render(): React.ReactElement<IVideoGalleryProps> {
    return (
      <div className={styles.videoGallery}>
        <div className={styles.videoGalleryTitle}>Video Gallery</div>
        <div className={styles.videoGalleryItems}>
          {this.state.videoGalleryList.map((item, index) => {
            return (
              <div key={index} className={styles.videoGalleryItem}>
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
