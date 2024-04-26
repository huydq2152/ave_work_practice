import * as React from "react";
import styles from "./Event.module.scss";
import { IEventProps } from "./IEventProps";
import { IEventState } from "./IEventState";
import { EventService } from "../../../services/EventService";
import { Helper } from "../../../commons/helper";
import { getSP } from "../../../pnpjsConfig";
import { IEvent } from "../../../interfaces/IEvent";
import { PagedItemCollection } from "@pnp/sp/items";
import LoadingAnimation from "../../../commons/loading/LoadingAnimation";
import ViewMore from "../../../commons/viewmore/ViewMore";
import HomeWorkImages from "../../../commons/image/HomeWorkImages";

export default class Event extends React.Component<IEventProps, IEventState> {
  private _eventService: EventService;
  private _helper: Helper;
  constructor(props: IEventProps, state: IEventState) {
    super(props);
    this.state = {
      eventList: [],
      hasNext: true,
      items: null,
      isLoading: true,
    };
    this._eventService = new EventService(
      props.listTitle,
      getSP(props.context)
    );
    this._helper = new Helper();
  }

  public getNewEventItems(newItems: PagedItemCollection<IEvent[]>) {
    let newEventItems = this.state.eventList;
    newItems.results.forEach((element) => {
      let today = new Date();
      if (today.getFullYear() === this._helper.getYear(element.Date)) {
        let item = {
          title: element.Title,
          day: this._helper.getDay(element.Date),
          month: this._helper.getMonth(element.Date),
          start: element.Start,
          end: element.End,
        };
        newEventItems.push(item);
      }
    });
    return newEventItems;
  }

  public async componentDidMount() {
    try {
      let newItems = await this._eventService.getPagedListItems(
        this.props.pageNum
      );
      let newEventItems = this.getNewEventItems(newItems);

      this.setState({
        eventList: newEventItems,
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
      let newEventItems = this.getNewEventItems(newItems);
      this.setState({
        eventList: newEventItems,
        hasNext: newItems.hasNext,
        items: newItems,
        isLoading: false,
      });
    }
  };

  public render(): React.ReactElement<IEventProps> {
    return (
      <div className={styles.events}>
        <div className={styles.eventsTitle}>Events</div>
        <div className={styles.eventsItems}>
          {this.state.eventList.map((item, index) => {
            return (
              <div key={index} className={styles.eventsItem}>
                <div className={styles.eventsDate}>
                  <div className={styles.eventsDay}>{item.day}</div>
                  <div className={styles.eventsMonth}>{item.month}</div>
                </div>
                <div className={styles.eventsContent}>
                  <div className={styles.eventsItemTitle}> {item.title}</div>
                  <div className={styles.eventsItemTime}>
                    <img
                      className={styles.eventsIcon}
                      src={HomeWorkImages.clock}
                    />
                    <div className={styles.eventsItemStartEnd}>
                      {item.start} - {item.end}
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
