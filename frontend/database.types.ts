export type Json =
  | string
  | number
  | boolean
  | null
  | { [key: string]: Json | undefined }
  | Json[]

export type Database = {
  public: {
    Tables: {
      Clients: {
        Row: {
          created_at: string
          id: number
          name: string
        }
        Insert: {
          created_at?: string
          id?: number
          name: string
        }
        Update: {
          created_at?: string
          id?: number
          name?: string
        }
        Relationships: []
      }
      CompositeParts: {
        Row: {
          component_part_id: number
          composite_id: number
          created_at: string
          id: number
          quantity_of_component: number
        }
        Insert: {
          component_part_id: number
          composite_id: number
          created_at?: string
          id?: number
          quantity_of_component: number
        }
        Update: {
          component_part_id?: number
          composite_id?: number
          created_at?: string
          id?: number
          quantity_of_component?: number
        }
        Relationships: [
          {
            foreignKeyName: "CompositeParts_component_part_id_fkey"
            columns: ["component_part_id"]
            isOneToOne: false
            referencedRelation: "Parts"
            referencedColumns: ["id"]
          },
          {
            foreignKeyName: "CompositeParts_composite_id_fkey"
            columns: ["composite_id"]
            isOneToOne: false
            referencedRelation: "Parts"
            referencedColumns: ["id"]
          },
        ]
      }
      ContactInfo: {
        Row: {
          client_id: number | null
          content: string | null
          created_at: string
          id: number
          project_id: number | null
          title: string | null
        }
        Insert: {
          client_id?: number | null
          content?: string | null
          created_at?: string
          id?: number
          project_id?: number | null
          title?: string | null
        }
        Update: {
          client_id?: number | null
          content?: string | null
          created_at?: string
          id?: number
          project_id?: number | null
          title?: string | null
        }
        Relationships: [
          {
            foreignKeyName: "ContactInfo_client_id_fkey"
            columns: ["client_id"]
            isOneToOne: false
            referencedRelation: "Clients"
            referencedColumns: ["id"]
          },
          {
            foreignKeyName: "ContactInfo_project_id_fkey"
            columns: ["project_id"]
            isOneToOne: false
            referencedRelation: "Projects"
            referencedColumns: ["id"]
          },
        ]
      }
      PartPresetComponents: {
        Row: {
          created_at: string
          id: number
          part_id: number | null
          part_preset_id: number | null
        }
        Insert: {
          created_at?: string
          id?: number
          part_id?: number | null
          part_preset_id?: number | null
        }
        Update: {
          created_at?: string
          id?: number
          part_id?: number | null
          part_preset_id?: number | null
        }
        Relationships: [
          {
            foreignKeyName: "PartPresetRelationships_part_id_fkey"
            columns: ["part_id"]
            isOneToOne: false
            referencedRelation: "Parts"
            referencedColumns: ["id"]
          },
          {
            foreignKeyName: "PartPresetRelationships_part_preset_id_fkey"
            columns: ["part_preset_id"]
            isOneToOne: false
            referencedRelation: "PartPresets"
            referencedColumns: ["id"]
          },
        ]
      }
      PartPresets: {
        Row: {
          created_at: string
          id: number
          name: string | null
          part_type: Database["public"]["Enums"]["PartType"] | null
          roof_sheet_id: number | null
        }
        Insert: {
          created_at?: string
          id?: number
          name?: string | null
          part_type?: Database["public"]["Enums"]["PartType"] | null
          roof_sheet_id?: number | null
        }
        Update: {
          created_at?: string
          id?: number
          name?: string | null
          part_type?: Database["public"]["Enums"]["PartType"] | null
          roof_sheet_id?: number | null
        }
        Relationships: [
          {
            foreignKeyName: "PartPresets_roof_sheet_id_fkey"
            columns: ["roof_sheet_id"]
            isOneToOne: false
            referencedRelation: "RoofSheets"
            referencedColumns: ["id"]
          },
        ]
      }
      Parts: {
        Row: {
          created_at: string
          id: number
          is_composite: boolean
          name: string | null
          price: number | null
        }
        Insert: {
          created_at?: string
          id?: number
          is_composite?: boolean
          name?: string | null
          price?: number | null
        }
        Update: {
          created_at?: string
          id?: number
          is_composite?: boolean
          name?: string | null
          price?: number | null
        }
        Relationships: []
      }
      Projects: {
        Row: {
          client_id: number | null
          created_at: string
          id: number
          location: string | null
          name: string
        }
        Insert: {
          client_id?: number | null
          created_at?: string
          id?: number
          location?: string | null
          name: string
        }
        Update: {
          client_id?: number | null
          created_at?: string
          id?: number
          location?: string | null
          name?: string
        }
        Relationships: [
          {
            foreignKeyName: "Projects_client_id_fkey"
            columns: ["client_id"]
            isOneToOne: false
            referencedRelation: "Clients"
            referencedColumns: ["id"]
          },
        ]
      }
      QuoteParts: {
        Row: {
          created_at: string
          id: number
          part_id: number
          part_quote_price: number | null
          quote_id: number
        }
        Insert: {
          created_at?: string
          id?: number
          part_id: number
          part_quote_price?: number | null
          quote_id: number
        }
        Update: {
          created_at?: string
          id?: number
          part_id?: number
          part_quote_price?: number | null
          quote_id?: number
        }
        Relationships: [
          {
            foreignKeyName: "QuoteParts_part_id_fkey"
            columns: ["part_id"]
            isOneToOne: false
            referencedRelation: "Parts"
            referencedColumns: ["id"]
          },
          {
            foreignKeyName: "QuoteParts_quote_id_fkey"
            columns: ["quote_id"]
            isOneToOne: false
            referencedRelation: "Quotes"
            referencedColumns: ["id"]
          },
        ]
      }
      Quotes: {
        Row: {
          client_id: number | null
          created_at: string
          date: string | null
          id: number
          quote_parts_id: number | null
          status: Database["public"]["Enums"]["QuoteStatus"]
        }
        Insert: {
          client_id?: number | null
          created_at?: string
          date?: string | null
          id?: number
          quote_parts_id?: number | null
          status?: Database["public"]["Enums"]["QuoteStatus"]
        }
        Update: {
          client_id?: number | null
          created_at?: string
          date?: string | null
          id?: number
          quote_parts_id?: number | null
          status?: Database["public"]["Enums"]["QuoteStatus"]
        }
        Relationships: []
      }
      RoofSheets: {
        Row: {
          created_at: string
          id: number
          name: string | null
          roof_type: number | null
        }
        Insert: {
          created_at?: string
          id?: number
          name?: string | null
          roof_type?: number | null
        }
        Update: {
          created_at?: string
          id?: number
          name?: string | null
          roof_type?: number | null
        }
        Relationships: [
          {
            foreignKeyName: "RoofSheets_roof_type_fkey1"
            columns: ["roof_type"]
            isOneToOne: false
            referencedRelation: "RoofTypes"
            referencedColumns: ["id"]
          },
        ]
      }
      RoofTypes: {
        Row: {
          created_at: string
          id: number
          name: string | null
        }
        Insert: {
          created_at?: string
          id?: number
          name?: string | null
        }
        Update: {
          created_at?: string
          id?: number
          name?: string | null
        }
        Relationships: []
      }
      Users: {
        Row: {
          created_at: string
          email: string | null
          id: string
          isAdmin: boolean | null
        }
        Insert: {
          created_at?: string
          email?: string | null
          id?: string
          isAdmin?: boolean | null
        }
        Update: {
          created_at?: string
          email?: string | null
          id?: string
          isAdmin?: boolean | null
        }
        Relationships: []
      }
    }
    Views: {
      [_ in never]: never
    }
    Functions: {
      check_if_user_is_admin: {
        Args: {
          id_to_check: string
        }
        Returns: boolean
      }
    }
    Enums: {
      PartType: "MidClamp" | "EndClamp"
      QuoteStatus:
        | "draft"
        | "sent"
        | "viewed"
        | "accepted"
        | "rejected"
        | "expired"
        | "revised"
        | "converted_to_invoice"
        | "cancelled"
    }
    CompositeTypes: {
      [_ in never]: never
    }
  }
}

type PublicSchema = Database[Extract<keyof Database, "public">]

export type Tables<
  PublicTableNameOrOptions extends
    | keyof (PublicSchema["Tables"] & PublicSchema["Views"])
    | { schema: keyof Database },
  TableName extends PublicTableNameOrOptions extends { schema: keyof Database }
    ? keyof (Database[PublicTableNameOrOptions["schema"]]["Tables"] &
        Database[PublicTableNameOrOptions["schema"]]["Views"])
    : never = never,
> = PublicTableNameOrOptions extends { schema: keyof Database }
  ? (Database[PublicTableNameOrOptions["schema"]]["Tables"] &
      Database[PublicTableNameOrOptions["schema"]]["Views"])[TableName] extends {
      Row: infer R
    }
    ? R
    : never
  : PublicTableNameOrOptions extends keyof (PublicSchema["Tables"] &
        PublicSchema["Views"])
    ? (PublicSchema["Tables"] &
        PublicSchema["Views"])[PublicTableNameOrOptions] extends {
        Row: infer R
      }
      ? R
      : never
    : never

export type TablesInsert<
  PublicTableNameOrOptions extends
    | keyof PublicSchema["Tables"]
    | { schema: keyof Database },
  TableName extends PublicTableNameOrOptions extends { schema: keyof Database }
    ? keyof Database[PublicTableNameOrOptions["schema"]]["Tables"]
    : never = never,
> = PublicTableNameOrOptions extends { schema: keyof Database }
  ? Database[PublicTableNameOrOptions["schema"]]["Tables"][TableName] extends {
      Insert: infer I
    }
    ? I
    : never
  : PublicTableNameOrOptions extends keyof PublicSchema["Tables"]
    ? PublicSchema["Tables"][PublicTableNameOrOptions] extends {
        Insert: infer I
      }
      ? I
      : never
    : never

export type TablesUpdate<
  PublicTableNameOrOptions extends
    | keyof PublicSchema["Tables"]
    | { schema: keyof Database },
  TableName extends PublicTableNameOrOptions extends { schema: keyof Database }
    ? keyof Database[PublicTableNameOrOptions["schema"]]["Tables"]
    : never = never,
> = PublicTableNameOrOptions extends { schema: keyof Database }
  ? Database[PublicTableNameOrOptions["schema"]]["Tables"][TableName] extends {
      Update: infer U
    }
    ? U
    : never
  : PublicTableNameOrOptions extends keyof PublicSchema["Tables"]
    ? PublicSchema["Tables"][PublicTableNameOrOptions] extends {
        Update: infer U
      }
      ? U
      : never
    : never

export type Enums<
  PublicEnumNameOrOptions extends
    | keyof PublicSchema["Enums"]
    | { schema: keyof Database },
  EnumName extends PublicEnumNameOrOptions extends { schema: keyof Database }
    ? keyof Database[PublicEnumNameOrOptions["schema"]]["Enums"]
    : never = never,
> = PublicEnumNameOrOptions extends { schema: keyof Database }
  ? Database[PublicEnumNameOrOptions["schema"]]["Enums"][EnumName]
  : PublicEnumNameOrOptions extends keyof PublicSchema["Enums"]
    ? PublicSchema["Enums"][PublicEnumNameOrOptions]
    : never

export type CompositeTypes<
  PublicCompositeTypeNameOrOptions extends
    | keyof PublicSchema["CompositeTypes"]
    | { schema: keyof Database },
  CompositeTypeName extends PublicCompositeTypeNameOrOptions extends {
    schema: keyof Database
  }
    ? keyof Database[PublicCompositeTypeNameOrOptions["schema"]]["CompositeTypes"]
    : never = never,
> = PublicCompositeTypeNameOrOptions extends { schema: keyof Database }
  ? Database[PublicCompositeTypeNameOrOptions["schema"]]["CompositeTypes"][CompositeTypeName]
  : PublicCompositeTypeNameOrOptions extends keyof PublicSchema["CompositeTypes"]
    ? PublicSchema["CompositeTypes"][PublicCompositeTypeNameOrOptions]
    : never
