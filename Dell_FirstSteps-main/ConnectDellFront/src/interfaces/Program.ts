import type Edition from "@/interfaces/Edition";
import type User from "@/interfaces/User";

export default interface Program{
    id?: number;
    name: string;
    description: string;
    startDate?: Date;
    endDate?: Date;
    editions?: Edition[];
    owners: User[];
    isBasic: boolean;
}