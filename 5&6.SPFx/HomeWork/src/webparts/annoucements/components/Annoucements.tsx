import * as React from "react";
import { IAnnoucementsProps } from "./IAnnoucementsProps";
import { AnnoucementService } from "../../../services/AnnoucementService";
import { PagedItemCollection } from "@pnp/sp/items";
import { IAnnoucement } from "../../../interfaces/IAnnoucement";
import { IAnnoucementsState } from "./IAnnoucementsState";
import { getSP } from "../../../pnpjsConfig";
import styles from "./Annoucements.module.scss";
import HomeWorkImages from "../../../commons/image/HomeWorkImages";
import LoadingAnimation from "../../../commons/loading/LoadingAnimation";
import ViewMore from "../../../commons/viewmore/ViewMore";
import { Helper } from "../../../commons/helper";

export default class Annoucements extends React.Component<
  IAnnoucementsProps,
  IAnnoucementsState
> {
  private _annoucementService: AnnoucementService;
  private _helper: Helper;

  constructor(props: IAnnoucementsProps, state: IAnnoucementsState) {
    super(props);
    this.state = {
      annList: [],
      hasNext: true,
      items: null,
      isLoading: true,
    };
    this._annoucementService = new AnnoucementService(
      props.listTitle,
      getSP(props.context)
    );
    this._helper = new Helper();
  }

  public getNewAnnItems(newItems: PagedItemCollection<IAnnoucement[]>) {
    let newAnnItems = this.state.annList;
    newItems.results.forEach((element) => {
      let item = {
        title: element.Title,
        content: element.Content,
        date: this._helper.formatDate(element.Date),
        category: element.Category,
        image: JSON.parse(element.Image).serverRelativeUrl,
      };
      newAnnItems.push(item);
    });
    return newAnnItems;
  }

  public async componentDidMount() {
    try {
      let newItems = await this._annoucementService.getPagedListItems(
        this.props.pageNum
      );
      let newAnnItems = this.getNewAnnItems(newItems);

      this.setState({
        annList: newAnnItems,
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
      let newAnnItems = this.getNewAnnItems(newItems);
      this.setState({
        annList: newAnnItems,
        hasNext: newItems.hasNext,
        items: newItems,
        isLoading: false,
      });
    }
  };

  public render(): React.ReactElement<IAnnoucementsProps> {
    return (
      <div className={styles.ann}>
        <div className={styles.annTitle}>Announcement</div>
        <div className={styles.annItems}>
          {this.state.annList.map((item, index) => {
            return (
              <div className={styles.annItem} key={index}>
                <div className={styles.annItemImage}>
                  <img width="160" height="120" src={item.image} alt=""></img>
                </div>
                <div className={styles.annItemContent}>
                  <div className={styles.annItemTitle}>{item.title} </div>
                  <div className={styles.annItemContentDetail}>
                    {item.content}
                  </div>
                  <div className={styles.annItemFooter}>
                    <div className={styles.annItemDateIcon}>
                      <img src={HomeWorkImages.date} alt="dateIcon"></img>
                    </div>
                    <div className={styles.annItemDate}>{item.date}</div>
                    <div className={styles.annItemCategory}>
                      {item.category}
                    </div>
                  </div>
                </div>
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
