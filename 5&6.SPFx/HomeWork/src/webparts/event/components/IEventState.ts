import { PagedItemCollection } from "@pnp/sp/items";
import { IEvent } from "../../../interfaces/IEvent";

export interface IEventState {
  eventList: {
    title: string;
    day: string;
    month: string;
    start: string;
    end: string;
  }[];
  hasNext: boolean;
  items: PagedItemCollection<IEvent[]>;
  isLoading: boolean;
}
