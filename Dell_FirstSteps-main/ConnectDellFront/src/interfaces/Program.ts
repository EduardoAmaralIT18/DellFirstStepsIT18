import type Edition from "@/interfaces/Edition";
import type User from "@/interfaces/User";


export default interface Program {
    id?: number,
    name: string,
    startDate?:Date,
    endDate?: Date,
    description: string,
    owners?: User[],
    editions?: Edition[],
    isBasic: boolean;
}

