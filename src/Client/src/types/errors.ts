export type Errors<T> = {
  [P in keyof T | 'generalErrors']?: string;
}
