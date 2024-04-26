import * as React from "react";
import { IQuickLinksProps } from "./IQuickLinksProps";
import { IQuickLinksState } from "./IQuickLinksState";
import { QuickLinkService } from "../../../services/QuickLinkService";
import { getSP } from "../../../pnpjsConfig";
import styles from "./QuickLinks.module.scss";

export default class QuickLinks extends React.Component<
  IQuickLinksProps,
  IQuickLinksState
> {
  private _quickLinkService: QuickLinkService;

  constructor(props: IQuickLinksProps, state: IQuickLinksState) {
    super(props);
    this.state = {
      quickLinksList: [],
    };
    this._quickLinkService = new QuickLinkService(
      props.listTitle,
      getSP(props.context)
    );
  }

  public async componentDidMount() {
    try {
      let newItems = this.state.quickLinksList;
      (await this._quickLinkService.getAllItems()).forEach((element) => {
        let item = {
          title: element.Title,
          image: JSON.parse(element.Image).serverRelativeUrl,
        };
        newItems.push(item);
      });
      this.setState({
        quickLinksList: newItems,
      });
    } catch (e) {
      console.log(e);
    }
  }

  public render(): React.ReactElement<IQuickLinksProps> {
    return (
      <div className={styles.quickLinks}>
        <div className={styles.quickLinksTitle}>Quick Links</div>
        <div className={styles.quickLinksItems}>
          {this.state.quickLinksList.map((item, index) => {
            return (
              <div key={index} className={styles.quickLinksItem}>
                <img src={item.image} alt=""></img>
                <div>
                  <p>{item.title}</p>
                </div>
              </div>
            );
          })}
        </div>
      </div>
    );
  }
}
