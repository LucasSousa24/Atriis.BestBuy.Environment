import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";

import {
    fetchProductsForTable,
    fetchUserByCredentials,
    updateFiltersForUser
} from "./services";

export const useFetchAllProductsByPages = () => {
    const queryClient = useQueryClient();
    return useMutation({
        mutationKey: ["useFetchAllProductsByPages"],
        mutationFn: (payload) => {
            return fetchProductsForTable(payload);
        },
        onError: () => {
            console.log("Sorry, couldn't fetch the product");
        },
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ["useFetchAllProductsByPages"] });
        },
    });
};

export const useGetUserByCredentialsMutation = () => {
    const queryClient = useQueryClient();
    
    return useMutation({
      mutationKey: ["useGetUserByCredentialsMutation"],
      mutationFn: () => {
        return fetchUserByCredentials();
      },
      onSuccess: () => {
        queryClient.invalidateQueries({
          queryKey: ["useGetUserByCredentialsMutation"],
        });
      },
    });
};

export const useUpdateFiltersForUserMutation = () => {
    const queryClient = useQueryClient();
  
    return useMutation({
      mutationKey: ["useUpdateFiltersForUserMutation"],
      mutationFn: (payload) => {
          return updateFiltersForUser(payload);
      },
      onError: () => {
        console.log("Sorry, couldn't update the user");
      },
      onSuccess: () => {
        queryClient.invalidateQueries({ queryKey: ["useUpdateFiltersForUserMutation"] });
      },
    });
  };

