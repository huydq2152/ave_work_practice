import * as React from "react";
import { INavigationProps } from "./INavigationProps";
import { INavigationState } from "./INavigationState";
import HomeWorkImages from "../../../commons/image/HomeWorkImages";
import styles from "./Navigation.module.scss";

export default class Navigation extends React.Component<
  INavigationProps,
  INavigationState
> {
  constructor(props: INavigationProps, state: INavigationState) {
    super(props);
    this.state = {
      navList: [
        { name: "About" },
        { name: "Services" },
        { name: "Products" },
        { name: "List" },
        { name: "Support" },
      ],
    };
  }

  public render(): React.ReactElement<INavigationProps> {
    return (
      <div className={styles.nav}>
        <div className={styles.navLogo}>
          <img src={HomeWorkImages.logo} alt="logo" />
        </div>
        <div className={styles.navItems}>
          {this.state.navList.map((item, index) => {
            return (
              <div key={index} className={styles.navItem}>
                {item.name}
              </div>
            );
          })}
        </div>
      </div>
    );
  }
}
