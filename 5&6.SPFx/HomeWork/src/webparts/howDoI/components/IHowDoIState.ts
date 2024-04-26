export interface IHowDoIState {
  howList: {
    id: number;
    title: string;
    question: string;
    answer: string;
  }[];
  isLoading: boolean;
  searchText: string;
  query: string;
  limit: number;
  activeQuestion: number;
}
