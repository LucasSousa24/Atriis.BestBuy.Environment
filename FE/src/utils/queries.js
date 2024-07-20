import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";

import {
    fetchImagesForTable
} from "./services";

export const useFetchAllImagesByPages = () => {
    const queryClient = useQueryClient();
    return useMutation({
        mutationKey: ["useSetupAllImages"],
        mutationFn: (payload) => {
            return fetchImagesForTable(payload);
        },
        onError: () => {
            console.log("Sorry, couldn't fetch the images");
        },
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ["useSetupAllImages"] });
        },
    });
};