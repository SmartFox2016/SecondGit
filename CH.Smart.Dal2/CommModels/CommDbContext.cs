using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CH.Smart.Dal2.CommModels
{
    /*
     * 将数据库中的表映射为程序中的实体类 2018-11-16
     * 注意事项：1.框架必须为 .net core  
     * 2.依赖的框架为Microsoft.EntityFrameworkCore.SqlServer
     *               Microsoft.EntityFrameworkCore.Tools
     *               Microsoft.VisualStudio.Web.CodeGeneration.Design
     * https://docs.microsoft.com/zh-cn/ef/core/get-started/aspnetcore/existing-db?view=aspnetcore-2.1
     */
    public partial class CommDbContext : DbContext
    {
        public CommDbContext()
        {
        }

        public CommDbContext(DbContextOptions<CommDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CommDataDay> CommDataDay { get; set; }
        public virtual DbSet<CommDataEx> CommDataEx { get; set; }
        public virtual DbSet<CommDataExReal> CommDataExReal { get; set; }
        public virtual DbSet<CommDataHeatRaw> CommDataHeatRaw { get; set; }
        public virtual DbSet<CommDataHour> CommDataHour { get; set; }
        public virtual DbSet<CommDataMonth> CommDataMonth { get; set; }
        public virtual DbSet<CommDataRaw> CommDataRaw { get; set; }
        public virtual DbSet<CommDataStat> CommDataStat { get; set; }
        public virtual DbSet<CommDeviceEx> CommDeviceEx { get; set; }
        public virtual DbSet<CommFrame> CommFrame { get; set; }
        public virtual DbSet<CommLog> CommLog { get; set; }
        public virtual DbSet<CommService> CommService { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=123.56.160.179,2478;initial catalog=SmartPower2_Comm_AC_Test;user id=smartpowerdev5;password=smartpowerdev5179;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-preview3-35497");

            modelBuilder.Entity<CommDataDay>(entity =>
            {
                entity.HasKey(e => new { e.DeviceId, e.StartTime });

                entity.ToTable("Comm_Data_Day");

                entity.Property(e => e.DeviceId).HasColumnName("Device_ID");

                entity.Property(e => e.StartTime)
                    .HasColumnName("Start_Time")
                    .HasColumnType("date");

                entity.Property(e => e.DataLevel)
                    .HasColumnName("Data_Level")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataRawId).HasColumnName("Data_Raw_ID");

                entity.Property(e => e.DataTime)
                    .HasColumnName("Data_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeltaValue)
                    .HasColumnName("Delta_Value")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.InsertTime)
                    .HasColumnName("Insert_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsEstimated).HasColumnName("Is_Estimated");

                entity.Property(e => e.TotalValue)
                    .HasColumnName("Total_Value")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("Update_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CommDataEx>(entity =>
            {
                entity.HasKey(e => new { e.DeviceId, e.DataKey, e.DataTime });

                entity.ToTable("Comm_Data_Ex");

                entity.HasIndex(e => e.DeviceId)
                    .HasName("Device_Id_Index");

                entity.Property(e => e.DeviceId).HasColumnName("Device_ID");

                entity.Property(e => e.DataKey)
                    .HasColumnName("Data_Key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DataTime)
                    .HasColumnName("Data_Time")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.DataValue)
                    .IsRequired()
                    .HasColumnName("Data_Value")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.CommDataEx)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comm_Data_Ex_Device_ID_Comm_Device_Ex_Device_ID");
            });

            modelBuilder.Entity<CommDataExReal>(entity =>
            {
                entity.HasKey(e => new { e.DeviceId, e.DataKey });

                entity.ToTable("Comm_Data_Ex_Real");

                entity.HasIndex(e => e.DeviceId)
                    .HasName("Device_Id_Index_copy1");

                entity.Property(e => e.DeviceId).HasColumnName("Device_ID");

                entity.Property(e => e.DataKey)
                    .HasColumnName("Data_Key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DataTime)
                    .HasColumnName("Data_Time")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.DataValue)
                    .IsRequired()
                    .HasColumnName("Data_Value")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.CommDataExReal)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comm_Data_Ex_Real_Device_ID_Comm_Device_Ex_Device_ID");
            });

            modelBuilder.Entity<CommDataHeatRaw>(entity =>
            {
                entity.ToTable("Comm_Data_Heat_Raw");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AvgValue)
                    .HasColumnName("Avg_Value")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.CurrentCooling)
                    .HasColumnName("Current_Cooling")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.CurrentFlow)
                    .HasColumnName("Current_Flow")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.CurrentHeatint)
                    .HasColumnName("Current_Heatint")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.DataFlags).HasColumnName("Data_Flags");

                entity.Property(e => e.DataLevel)
                    .HasColumnName("Data_Level")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataTime)
                    .HasColumnName("Data_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataType)
                    .HasColumnName("Data_Type")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DayHeating)
                    .HasColumnName("Day_Heating")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.DeltaValue)
                    .HasColumnName("Delta_Value")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.DeviceId).HasColumnName("Device_ID");

                entity.Property(e => e.EndTime)
                    .HasColumnName("End_Time")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.FlowIn)
                    .HasColumnName("Flow_In")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.FlowOut)
                    .HasColumnName("Flow_Out")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.HeatingPower)
                    .HasColumnName("Heating_Power")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.HmeterType).HasColumnName("HMeter_Type");

                entity.Property(e => e.InsertTime)
                    .HasColumnName("Insert_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PressureIn)
                    .HasColumnName("Pressure_In")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.PressureOut)
                    .HasColumnName("Pressure_Out")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.RealTime)
                    .HasColumnName("Real_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.SpeedIn)
                    .HasColumnName("Speed_In")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.SpeedOut)
                    .HasColumnName("Speed_Out")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.St1)
                    .HasColumnName("ST1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.St2)
                    .HasColumnName("ST2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasColumnName("Start_Time")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.StartTimeRaw)
                    .HasColumnName("Start_Time_Raw")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.TempIn)
                    .HasColumnName("Temp_In")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.TempOut)
                    .HasColumnName("Temp_Out")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.TotalFlow)
                    .HasColumnName("Total_Flow")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.TotalTime)
                    .HasColumnName("Total_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalValue)
                    .HasColumnName("Total_Value")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("Update_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CommDataHour>(entity =>
            {
                entity.HasKey(e => new { e.DeviceId, e.StartTime });

                entity.ToTable("Comm_Data_Hour");

                entity.HasIndex(e => new { e.StartTime, e.DeltaValue, e.DeviceId })
                    .HasName("IX_Comm_Data_Hour_Device_ID_Start_Time_Delta_Value");

                entity.Property(e => e.DeviceId).HasColumnName("Device_ID");

                entity.Property(e => e.StartTime)
                    .HasColumnName("Start_Time")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.DataLevel)
                    .HasColumnName("Data_Level")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataRawId).HasColumnName("Data_Raw_ID");

                entity.Property(e => e.DataTime)
                    .HasColumnName("Data_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeltaValue)
                    .HasColumnName("Delta_Value")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.InsertTime)
                    .HasColumnName("Insert_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsEstimated).HasColumnName("Is_Estimated");

                entity.Property(e => e.TotalValue)
                    .HasColumnName("Total_Value")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("Update_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CommDataMonth>(entity =>
            {
                entity.HasKey(e => new { e.DeviceId, e.StartTime });

                entity.ToTable("Comm_Data_Month");

                entity.Property(e => e.DeviceId).HasColumnName("Device_ID");

                entity.Property(e => e.StartTime)
                    .HasColumnName("Start_Time")
                    .HasColumnType("date");

                entity.Property(e => e.DataLevel)
                    .HasColumnName("Data_Level")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataRawId).HasColumnName("Data_Raw_ID");

                entity.Property(e => e.DataTime)
                    .HasColumnName("Data_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeltaValue)
                    .HasColumnName("Delta_Value")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.InsertTime)
                    .HasColumnName("Insert_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsEstimated).HasColumnName("Is_Estimated");

                entity.Property(e => e.TotalValue)
                    .HasColumnName("Total_Value")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("Update_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CommDataRaw>(entity =>
            {
                entity.ToTable("Comm_Data_Raw");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AvgValue)
                    .HasColumnName("Avg_Value")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.DataFlags).HasColumnName("Data_Flags");

                entity.Property(e => e.DataLevel)
                    .HasColumnName("Data_Level")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataTime)
                    .HasColumnName("Data_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataType)
                    .HasColumnName("Data_Type")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DeltaValue)
                    .HasColumnName("Delta_Value")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.DeviceId).HasColumnName("Device_ID");

                entity.Property(e => e.EndTime)
                    .HasColumnName("End_Time")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.InsertTime)
                    .HasColumnName("Insert_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StartTime)
                    .HasColumnName("Start_Time")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.StartTimeRaw)
                    .HasColumnName("Start_Time_Raw")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.TotalValue)
                    .HasColumnName("Total_Value")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("Update_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CommDataStat>(entity =>
            {
                entity.HasKey(e => e.DeviceId);

                entity.ToTable("Comm_Data_Stat");

                entity.Property(e => e.DeviceId)
                    .HasColumnName("Device_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdjValue)
                    .HasColumnName("Adj_Value")
                    .HasColumnType("decimal(9, 4)");

                entity.Property(e => e.DataAvg)
                    .HasColumnName("Data_Avg")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.DataTime)
                    .HasColumnName("Data_Time")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.DataValue)
                    .HasColumnName("Data_Value")
                    .HasColumnType("decimal(12, 4)");

                entity.Property(e => e.DeviceState)
                    .HasColumnName("Device_State")
                    .HasDefaultValueSql("((8))");

                entity.Property(e => e.ExtraData)
                    .HasColumnName("Extra_Data")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FanStat)
                    .HasColumnName("Fan_Stat")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HostCompInfo)
                    .HasColumnName("Host_Comp_Info")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.InitTime)
                    .HasColumnName("Init_Time")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastInst)
                    .HasColumnName("Last_Inst")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NeedReQuery).HasColumnName("Need_ReQuery");

                entity.Property(e => e.OfflineCount).HasColumnName("Offline_Count");

                entity.Property(e => e.OfflineTime)
                    .HasColumnName("Offline_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.OldState).HasColumnName("__Old_State");

                entity.Property(e => e.PowerOn).HasColumnName("Power_On");

                entity.Property(e => e.PowerRealResult)
                    .HasColumnName("PowerReal_Result")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ReQueryTime)
                    .HasColumnName("ReQuery_Time")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.RoomTemp)
                    .HasColumnName("Room_Temp")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.ServiceId).HasColumnName("Service_ID");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("Update_Time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ValveStat)
                    .HasColumnName("Valve_Stat")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.WaterTempIn)
                    .HasColumnName("Water_Temp_In")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.WaterTempOut)
                    .HasColumnName("Water_Temp_Out")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.WorkType).HasColumnName("Work_Type");

                entity.HasOne(d => d.Device)
                    .WithOne(p => p.CommDataStat)
                    .HasForeignKey<CommDataStat>(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comm_Data_Stat_Device_ID_Comm_Device_Ex_Device_ID");
            });

            modelBuilder.Entity<CommDeviceEx>(entity =>
            {
                entity.HasKey(e => e.DeviceId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Comm_Device_Ex");

                entity.HasIndex(e => e.Path)
                    .HasName("Index_Device_Path")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.DeviceId)
                    .HasColumnName("Device_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeviceName)
                    .HasColumnName("Device_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceRawIdx).HasColumnName("Device_Raw_IDX");

                entity.Property(e => e.DeviceRawSn)
                    .HasColumnName("Device_Raw_SN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceRawSn2)
                    .HasColumnName("Device_Raw_SN2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceType).HasColumnName("Device_Type");

                entity.Property(e => e.ExtraConfig)
                    .HasColumnName("Extra_Config")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.FrameId).HasColumnName("Frame_ID");

                entity.Property(e => e.IsDirty).HasColumnName("Is_Dirty");

                entity.Property(e => e.Note)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TrackingOldId).HasColumnName("__Tracking_Old_ID");

                entity.Property(e => e.TrackingOldType).HasColumnName("__Tracking_Old_Type");

                entity.HasOne(d => d.Frame)
                    .WithMany(p => p.CommDeviceEx)
                    .HasForeignKey(d => d.FrameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comm_Devi__Frame__1BB31344");
            });

            modelBuilder.Entity<CommFrame>(entity =>
            {
                entity.HasKey(e => e.FrameId);

                entity.ToTable("Comm_Frame");

                entity.Property(e => e.FrameId)
                    .HasColumnName("Frame_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DefServiceId).HasColumnName("Def_Service_ID");

                entity.Property(e => e.ExtraConfig)
                    .HasColumnName("Extra_Config")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.FrameHwVer)
                    .HasColumnName("Frame_Hw_Ver")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FrameName)
                    .HasColumnName("Frame_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FrameRawName)
                    .HasColumnName("Frame_Raw_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FrameSwVer)
                    .HasColumnName("Frame_Sw_Ver")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FrameType)
                    .HasColumnName("Frame_Type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FrameVendor)
                    .HasColumnName("Frame_Vendor")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceGroup)
                    .HasColumnName("Service_Group")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('unknown')");
            });

            modelBuilder.Entity<CommLog>(entity =>
            {
                entity.ToTable("Comm_Log");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DeviceId).HasColumnName("Device_ID");

                entity.Property(e => e.EndPoint)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime)
                    .HasColumnName("End_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.GatewayId).HasColumnName("Gateway_ID");

                entity.Property(e => e.IsEnd).HasColumnName("Is_End");

                entity.Property(e => e.Msg)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Operator)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SrvId).HasColumnName("Srv_ID");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tag2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.CommLog)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("FK_Comm_Log_Device_ID_Comm_Device_Ex_Device_ID");

                entity.HasOne(d => d.Srv)
                    .WithMany(p => p.CommLog)
                    .HasForeignKey(d => d.SrvId)
                    .HasConstraintName("FK__Comm_Log__Srv_ID__28ED12D1");
            });

            modelBuilder.Entity<CommService>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.ToTable("Comm_Service");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("Service_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CtlPort)
                    .HasColumnName("Ctl_Port")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CtlPortV2)
                    .HasColumnName("Ctl_Port_V2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataPort)
                    .HasColumnName("Data_Port")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DbgPort)
                    .HasColumnName("Dbg_Port")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Desc)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsMaster).HasColumnName("Is_Master");

                entity.Property(e => e.ServiceGroup)
                    .HasColumnName("Service_Group")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('unknown')");

                entity.Property(e => e.ServiceState).HasColumnName("Service_State");
            });
        }
    }
}
