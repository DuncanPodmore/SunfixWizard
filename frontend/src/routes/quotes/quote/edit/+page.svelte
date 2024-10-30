<script lang="ts">
    import { onMount } from 'svelte';
    import {supabase} from "../../../../auth/supabase";
    import type {Part, Quote, QuotePart} from "../../../../data/models";

    export let params;
    let quoteId: number | null = params.id ? parseInt(params.id) : null;

    let quote: Quote = {
        id: null,
        created_at: new Date().toISOString(),
        company_address: '',
        client_address: '',
    };

    let quoteParts: Array<QuotePart & { part: Part }> = [];

    onMount(async () => {
        if (quoteId) {
            // Fetch the existing quote
            const { data: quoteData, error: quoteError } = await supabase
                .from('Quotes')
                .select('*')
                .eq('id', quoteId)
                .single();

            if (quoteError) {
                console.error('Error fetching quote:', quoteError);
            } else {
                quote = quoteData;
            }

            // Fetch associated quote parts
            const { data: quotePartsData, error: quotePartsError } = await supabase
                .from('QuoteParts')
                .select('*, part:Parts(*)')
                .eq('quote_id', quoteId);

            if (quotePartsError) {
                console.error('Error fetching quote parts:', quotePartsError);
            } else {
                quoteParts = quotePartsData;
            }
        }
    });

    async function saveQuote() {
        // Implement save logic as shown earlier
    }
</script>

<!-- Your HTML template with dynamic bindings -->
<div class="mx-20 flex flex-col overflow-hidden rounded-lg bg-white shadow-sm dark:bg-gray-800 dark:text-gray-100 print:shadow-none">
    <div class="grow p-5 print:p-0">
        <div class="mx-auto lg:w-10/12 print:w-full">
            <!-- Invoice Header -->
            <div class="flex items-center justify-between border-b border-gray-100 py-10 dark:border-gray-700/50 print:pt-0">
                <h3 class="font-semibold">Invoice #{quote.id ?? 'New'}</h3>
                <!-- ... -->
            </div>
            <!-- END Invoice Header -->

            <!-- Invoice Info -->
            <!-- ... (Company Info and Client Info with dynamic data) -->

            <!-- Responsive Table Container -->
            <div class="min-w-full overflow-x-auto rounded border border-gray-100 bg-white dark:border-gray-700 dark:bg-gray-800">
                <!-- Bordered Table -->
                <table class="min-w-full whitespace-nowrap align-middle text-sm">
                    <!-- Table Header -->
                    <!-- ... -->
                    <!-- Table Body -->
                    <tbody>
                    {#each quoteParts as quotePart}
                        <tr class="border-b border-gray-100 dark:border-gray-700/50">
                            <td class="p-3">
                                <p class="mb-1 font-semibold">{quotePart.part.name}</p>
                            </td>
                            <td class="p-3 text-center">
                                <div class="inline-flex rounded-lg bg-blue-100 px-2 py-1 text-sm font-semibold leading-4 text-blue-700 dark:bg-blue-200 dark:text-blue-900">
                                    {quotePart.quantity}
                                </div>
                            </td>
                            <td class="p-3 text-right">
                                ${quotePart.part.price.toFixed(2)}
                            </td>
                            <td class="p-3 text-right">
                                ${(quotePart.quantity * quotePart.part.price).toFixed(2)}
                            </td>
                        </tr>
                    {/each}
                    <!-- Subtotal, VAT, Total calculations -->
                    </tbody>
                </table>
                <!-- END Bordered Table -->
            </div>
            <!-- END Responsive Table Container -->

            <!-- Footer -->
            <!-- ... -->
        </div>
    </div>
</div>

<button on:click={saveQuote}>Save Quote</button>
