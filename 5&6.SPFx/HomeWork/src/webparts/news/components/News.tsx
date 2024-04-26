import * as React from "react";
import { INewsProps } from "./INewsProps";
import { INewsState } from "./INewsState";
import { NewService } from "../../../services/NewService";
import { getSP } from "../../../pnpjsConfig";
import { Helper } from "../../../commons/helper";
import { INew } from "../../../interfaces/INew";
import { PagedItemCollection } from "@pnp/sp/items";
import ViewMore from "../../../commons/viewmore/ViewMore";
import LoadingAnimation from "../../../commons/loading/LoadingAnimation";
import styles from "./News.module.scss";
import HomeWorkImages from "../../../commons/image/HomeWorkImages";

export default class News extends React.Component<INewsProps, INewsState> {
  private _newService: NewService;
  private _helper: Helper;
  constructor(props: INewsProps, state: INewsState) {
    super(props);
    this.state = {
      newList: [],
      hasNext: true,
      items: null,
      isLoading: true,
    };
    this._newService = new NewService(props.listTitle, getSP(props.context));
    this._helper = new Helper();
  }

  public getNewNewItems(newItems: PagedItemCollection<INew[]>) {
    let newNewItems = this.state.newList;
    newItems.results.forEach((element) => {
      let item = {
        title: element.Title,
        content: element.Content,
        date: this._helper.formatDate(element.Date),
        image: JSON.parse(element.Image).serverRelativeUrl,
      };
      newNewItems.push(item);
    });
    return newNewItems;
  }

  public async componentDidMount() {
    try {
      let newItems = await this._newService.getPagedListItems(
        this.props.pageNum
      );
      let newNewItems = this.getNewNewItems(newItems);

      this.setState({
        newList: newNewItems,
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
      let newNewItems = this.getNewNewItems(newItems);
      this.setState({
        newList: newNewItems,
        hasNext: newItems.hasNext,
        items: newItems,
        isLoading: false,
      });
    }
  };

  public render(): React.ReactElement<INewsProps> {
    return (
      <div className={styles.new}>
        <div className={styles.newTitle}>News</div>
        <div className={styles.newItems}>
          {this.state.newList.map((item, index) => {
            return (
              <div className={styles.newItem} key={index}>
                <div className={styles.newItemImage}>
                  <img width="160" height="120" src={item.image} alt=""></img>
                </div>
                <div className={styles.newItemContent}>
                  <div className={styles.newItemTitle}>{item.title} </div>
                  <div className={styles.newItemContentDetail}>
                    {item.content}
                  </div>
                  <div className={styles.newItemFooter}>
                    <div className={styles.newItemDateIcon}>
                      <img src={HomeWorkImages.date} alt="dateIcon"></img>
                    </div>
                    <div className={styles.newItemDate}>{item.date}</div>
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
