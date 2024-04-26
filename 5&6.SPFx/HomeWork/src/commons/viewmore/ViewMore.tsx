import * as React from "react";
import Image from "../image/HomeWorkImages";
import styles from "./ViewMore.module.scss";
import { IViewMoreProps } from "./IViewMoreProps";
class ViewMore extends React.Component<IViewMoreProps> {
  public render() {
    return (
      <div className={styles.viewMore} onClick={this.props.onClick}>
        <div className={styles.viewMoreContent}> View more </div>
        <div className={styles.viewMoreIcon}>
          <img src={Image.arrowicon} alt="" />
        </div>
      </div>
    );
  }
}

export default ViewMore;
