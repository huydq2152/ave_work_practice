import { PagedItemCollection } from "@pnp/sp/items";
import { IAnnoucement } from "../../../interfaces/IAnnoucement";
export interface IAnnoucementsState {
  annList: {
    title: string;
    content: string;
    date: string;
    category: string;
    image: string;
  }[];
  hasNext: boolean;
  items: PagedItemCollection<IAnnoucement[]>;
  isLoading: boolean;
}
