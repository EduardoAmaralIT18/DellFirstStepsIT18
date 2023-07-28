import type Edition from "@/interfaces/Edition";

export default interface Program {
    id?: number,
    name: string,
    startDate:string,
    endDate?: string,
    description: string,
    editions?: Edition[],
    isBasic: boolean;
}