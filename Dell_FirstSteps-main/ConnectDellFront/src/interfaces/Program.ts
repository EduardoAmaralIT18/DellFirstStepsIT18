import type Edition from "@/interfaces/Edition";

export default interface Program{
    id?: number;
    name: string;
    description: string;
    startDate?: Date;
    endDate?: Date;
    editions?: Edition[];
    owners: user[];
}