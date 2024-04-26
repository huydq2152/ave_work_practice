import { PagedItemCollection } from "@pnp/sp/items";
import { INew } from "../../../interfaces/INew";

export interface INewsState {
  newList: {
    title: string;
    content: string;
    date: string;
    image: string;
  }[];
  hasNext: boolean;
  items: PagedItemCollection<INew[]>;
  isLoading: boolean;
}
