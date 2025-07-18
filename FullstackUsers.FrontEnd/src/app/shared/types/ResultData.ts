export interface ResultData<T> {
  items: T;
  totalItems: number;
  totalPages: number;
  hasNextPage: boolean;
}
