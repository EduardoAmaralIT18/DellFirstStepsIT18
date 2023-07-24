import User from "./User"
export default interface Edition{
    id?: number;
    name: string;
    numberOfInterns: number;
    members: User[];
    description: string;
    curriculum: string;
    mode: number;
    startDate?: Date | string;
    endDate?: Date | string;
    program: number;
}