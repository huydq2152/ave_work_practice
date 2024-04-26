import * as React from "react";
import HomeWorkImages from "../../../commons/image/HomeWorkImages";
import LoadingAnimation from "../../../commons/loading/LoadingAnimation";
import ViewMore from "../../../commons/viewmore/ViewMore";
import { getSP } from "../../../pnpjsConfig";
import { HowDoIService } from "../../../services/HowDoIService";
import styles from "./HowDoI.module.scss";
import { IHowDoIProps } from "./IHowDoIProps";
import { IHowDoIState } from "./IHowDoIState";

export default class HowDoI extends React.Component<
  IHowDoIProps,
  IHowDoIState
> {
  private _howService: HowDoIService;
  constructor(props: IHowDoIProps, state: IHowDoIState) {
    super(props);
    this.state = {
      howList: [],
      isLoading: true,
      searchText: "",
      query: "",
      limit: 4,
      activeQuestion: 0,
    };
    this._howService = new HowDoIService(props.listTitle, getSP(props.context));
    this.searchHandler = this.searchHandler.bind(this);
    this.handleChange = this.handleChange.bind(this);
    this.handleKeyDown = this.handleKeyDown.bind(this);
    this.toggleClass = this.toggleClass.bind(this);
    this.onHandleViewMore = this.toggleClass.bind(this);
  }

  public getNewHowItems(newItems: any[]) {
    let newHowItems = this.state.howList;
    newItems.forEach(
      (element: { Id: any; Title: any; Question: any; Answer: any }) => {
        let item = {
          id: element.Id,
          title: element.Title,
          question: element.Question,
          answer: element.Answer,
        };
        newHowItems.push(item);
      }
    );
    return newHowItems;
  }

  public async componentDidMount() {
    try {
      let howItems = await this._howService.getAllItems();
      let newHowItems = this.getNewHowItems(howItems);

      this.setState({
        howList: newHowItems,
        isLoading: false,
      });
    } catch (e) {
      console.log(e);
    }
  }

  public onHandleViewMore() {
    this.setState({
      isLoading: false,
      limit: this.state.limit + 4,
    });
  }

  public searchHandler() {
    if (this.state.query) {
      var lowerCase = this.state.query.toLowerCase();
      this.setState({ searchText: lowerCase, limit: 4 });
    } else {
      this.setState({ searchText: "", limit: 4 });
    }
  }

  handleChange(e: { target: { value: any } }) {
    this.setState({ query: e.target.value });
  }

  handleKeyDown(e: { key: string }) {
    if (e.key === "Enter") {
      this.searchHandler();
    }
  }

  public toggleClass(index: number) {
    this.setState({
      activeQuestion: this.state.activeQuestion === index ? 0 : index,
    });
  }

  public render(): React.ReactElement<IHowDoIProps> {
    return (
      <div className={styles.hdi}>
        <div className={styles.hdiTitle}>How Do I</div>
        <div className={styles.hdiSearch}>
          <img
            className={styles.hdiSearchIcon}
            src={HomeWorkImages.search}
            alt=""
            onClick={this.searchHandler}
          />
          <input
            className={styles.hdiSearchInput}
            type="text"
            placeholder="Find Questions"
            onChange={this.handleChange}
            onKeyDown={this.handleKeyDown}
          />
        </div>

        <div className={styles.hdiItems}>
          <div className={styles.hdiItem}>
            {this.state.howList
              .filter((el) => {
                if (this.state.searchText === "") {
                  return el;
                } else {
                  return el.question
                    .toLowerCase()
                    .includes(this.state.searchText);
                }
              })
              .slice(0, this.state.limit)
              .map((item, index) =>
                item.id === this.state.activeQuestion ? (
                  <div key={index}>
                    <div
                      className={styles.hdiItemElementActive}
                      onClick={() => this.toggleClass(item.id)}>
                      <img
                        className={styles.hdiItemCollapse}
                        src={HomeWorkImages.expand}
                        alt="View more"
                      />
                      <div
                        className={styles.hdiItemQuestionexpand}
                        onClick={() => this.toggleClass(item.id)}>
                        {item.question}
                      </div>
                    </div>
                    <div className={styles.hdiItemAnswerContent}>
                      <div className={styles.hdiItemAuthor}>A:</div>
                      <div className={styles.hdiItemAnswer}>{item.answer}</div>
                    </div>
                  </div>
                ) : (
                  <div
                    className={styles.hdiItemElement}
                    key={index}
                    onClick={() => this.toggleClass(item.id)}>
                    <img
                      className={styles.hdiItemCollapse}
                      src={HomeWorkImages.collapse}
                      alt="View more"
                    />
                    <div
                      className={styles.hdiItemQuestion}
                      onClick={() => this.toggleClass(item.id)}>
                      {item.question}
                    </div>
                  </div>
                )
              )}
          </div>
        </div>

        {this.state.isLoading && <LoadingAnimation />}
        {this.state.howList.length > this.state.limit && (
          <ViewMore onClick={this.onHandleViewMore} />
        )}
      </div>
    );
  }
}
