import type User from "./User";
export default interface Edition {
  id: number;
  name: string;
  numberOfInterns: number;
  members: User[];
  description: string;
  curriculum?: string;
  mode: number;
  startDate: string;
  endDate: string;
  program: number;
}
