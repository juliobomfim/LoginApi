export interface UserClaim {
  type: string;
  value: string;
}

export interface Response {
  type: Type;
  message: string;
}

export enum Type {
  Success,
  Failure,
  Warning
}
