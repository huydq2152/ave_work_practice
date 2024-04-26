import * as React from "react";
import styles from "./LoadingAnimation.module.scss";
export interface ILoadingAnimationProps {}

class LoadingAnimation extends React.Component<ILoadingAnimationProps> {
  public render() {
    return (
      <div className={styles.spinner}>
        <div className={styles.spinnerBorder} role="status">
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
          <div></div>
        </div>
      </div>
    );
  }
}
export default LoadingAnimation;
